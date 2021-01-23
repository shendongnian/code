    namespace Importer
    {
    class ImportHandler
    {
        List<string> inputString;
        Readanyfile read= new Readanyfile();
        int num_frames, start, end, frame_rate;
        GraphicsDevice graphicsDevice;
        int index = 0;
        classes_stat.KeyFrameAnimation Animation;
        public ImportHandler(GraphicsDevice graphicsDevice, Game game,string _inputFile)
        {
            this.graphicsDevice = graphicsDevice;
            this.inputString = read.Load();
            ReadRawScene();
        }
        
        string ReadStringValue(string str)
        {
            var value = str.Split(' ')[1]; 
           return value; 
        }
        public int strToInt(string str)
        {
            var value = str.Split(' ')[1]; 
           return int.Parse(value); 
        
        }
        public float strToFloat(string str)
        {
            var value = str.Split(' ')[1]; 
            return float.Parse(value);
        }
        public double strToDouble(string str)
        {
            var value = str.Split(' ')[1]; 
            try
            {
                return double.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                return (double) 0.1f;
            }
            
            
        }
         private static float[] ParseFloatArray(string str, int count)
        {
            var floats = new float[count];
            var segments = str.Split(' ');
            for (int i = 0; i < count; i++)
            {
                if (i < segments.Length)
                {
                    try
                    {
                        floats[i] = (float)double.Parse(segments[i], System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        floats[i] = 0;
                    }
                }
            }
            return floats;
        }
    private Vector2 ParseVector2(string str)
        {
            var components = ParseFloatArray(str, 3);
 
            var vec = new Vector2(components[0], components[1]);
 
            return components[2] == 0
                ? vec
                : vec / components[2];
        }
       
        private Vector3 ParseVector3(string str)
        {
            var components = ParseFloatArray(str, 4);
 
            var vec = new Vector3(components[0], components[1], components[2]);
 
            return components[3] == 0
                ? vec
                : vec / components[3];
        }
        public void ReadRawScene()
        {
            List<classes_stat.KeyFrame> tempAni = new List<classes_stat.KeyFrame>();
            for (int i = 0; i < inputString.Count(); i++ )
            {
                if (inputString[i].StartsWith("num_frames"))
                {
                    num_frames = strToInt(inputString[i]);
                }
                if (inputString[i].StartsWith("start"))
                {
                    start = strToInt(inputString[i]);
                }
                if (inputString[i].StartsWith("end"))
                {
                    end = strToInt(inputString[i]);
                }
                if (inputString[i].StartsWith("frame_rate"))
                {
                    frame_rate = strToInt(inputString[i]);
                }
                if (inputString[i].StartsWith("frame"))
                { tempAni.Add(ReadFrames(strToInt(inputString[i]), i, inputString));
                }
                Animation = new classes_stat.KeyFrameAnimation(frame_rate, start, end, num_frames, tempAni);
            }
        }
        public classes_stat.KeyFrame ReadFrames(int frameIndex,int currentIndex, List<string> inputString )
        {
            List<MeshFromBinary> tempOutPutMesh = new List<MeshFromBinary>();
            List<CameraFromBinary> tempOutPutCam = new List<CameraFromBinary>();
            for (int i = currentIndex + 3; i < inputString.Count(); i++)
            {
                if (inputString[i].StartsWith("meshes"))
                {
                    int count = strToInt(inputString[i]);
                    for (int x = 0; x < count; x++)
                    {
                        MeshFromBinary temp = ReadMeshes(i, inputString);
                        tempOutPutMesh.Add(temp);
                    }
                }
                if (inputString[i].StartsWith("cameras"))
                {
                    int count = strToInt(inputString[i]);
                    for (int x = 0; x < count; x++)
                    {
                        tempOutPutCam.Add(ReadCameras(i, inputString));
                    }
                }
                if (inputString[i].StartsWith("frame"))
                {
                    break;
                }
                
            }
            classes_stat.KeyFrame frame = new classes_stat.KeyFrame(frameIndex, tempOutPutMesh, tempOutPutCam);
            return frame;
        }
        private MeshFromBinary ReadMeshes(int currentIndex, List<string> inputString)
        {
            int tempCurrentIndex = 0;
            List<classes_stat.MyOwnVertexFormat> temp = new List<classes_stat.MyOwnVertexFormat>();
            string name;
            Texture2D color = ContentTextures.crateTexture; 
            Texture2D bump = ContentTextures.crateTexture;
            double bumpDepth = 0;
            List<Vector3> tmpPos = new List<Vector3>();
            List<Vector3> tmpNor = new List<Vector3>();
            List<Vector3> tmpTan = new List<Vector3>();
            List<Vector2> tmpUV = new List<Vector2>();
            int numberofvertices = 0;
            for (int i = currentIndex; i < inputString.Count(); i++)
            {
                if (inputString[i].StartsWith("name"))
                {
                    name = ReadStringValue(inputString[i]);
                }
                if (inputString[i].StartsWith("color"))
                {
                    string tmp = ReadStringValue(inputString[i]);
                    System.IO.FileStream stream = new System.IO.FileStream(tmp, System.IO.FileMode.Open);
                    color = Texture2D.FromStream(graphicsDevice, stream);
                    stream.Close();
                    stream.Dispose();
                    //temp.Add(ReadStringValue());
                }
                if (inputString[i].StartsWith("normalMap"))
                {
                    string tmp = ReadStringValue(inputString[i]);
                    System.IO.FileStream stream = new System.IO.FileStream(tmp, System.IO.FileMode.Open);
                    bump = Texture2D.FromStream(graphicsDevice, stream);
                    stream.Close();
                    stream.Dispose();
                }
                if (inputString[i].StartsWith("bumpDepth"))
                {
                    bumpDepth = strToDouble(inputString[i]);
                }
                if (inputString[i].StartsWith("vertices"))
                {
                    numberofvertices = strToInt(inputString[i]);
                }
                if (inputString[i].StartsWith("v"))
                {
                    tempCurrentIndex = (i - 1);
                    break;
                }
            }
            for (int i = tempCurrentIndex; i < inputString.Count(); i++)
            {
                if (inputString[i].StartsWith("v"))
                {
                    tmpPos.Add(ParseVector3(inputString[i]));
                }
                if (inputString[i].StartsWith("vn"))
                {
                    tmpNor.Add(ParseVector3(inputString[i]));
                }
                if (inputString[i].StartsWith("t"))
                {
                    tmpTan.Add(ParseVector3(inputString[i]));
                }
                if (inputString[i].StartsWith("vt"))
                {
                    tmpUV.Add(ParseVector2(inputString[i]));
                }
                if (inputString[i].StartsWith("cameras"))
                {
                    break;
                }
                if (inputString[i].StartsWith("name"))
                {
                    break;
                }
            }
            for (int i = 0; i < numberofvertices; i++)
            {
                
                temp.Add(new classes_stat.MyOwnVertexFormat(tmpPos[i], tmpNor[i], tmpTan[i], tmpUV[i]));
                
            }
            MeshFromBinary mMesh;
            return mMesh = new MeshFromBinary(graphicsDevice, temp, color, bump, bumpDepth);
        }
        private CameraFromBinary ReadCameras(int currentIndex, List<string> inputString)
        {
            int tempCurrentIndex = 0;
            CameraFromBinary temp;
            string name;
            Vector3 tmpPos = new Vector3();
            Vector3 tmpDir = new Vector3();
            Vector3 tmpUp = new Vector3();
            double tmpV_FOV = new double();
            double tmpH_FOV = new double(); 
            double tmpNear_clipping_plane = new double();
            double tmpFar_clipping_plane = new double();
            double tmpAspect_ratio = new double();
            for (int i = currentIndex; i < inputString.Count(); i++)
            {
                if (inputString[i].StartsWith("name"))
                {
                    System.Console.WriteLine(ReadStringValue(inputString[i]));
                    name = ReadStringValue(inputString[i]);
                    tempCurrentIndex = (i + 1);
                    break;
                }
            }
            for (int i = tempCurrentIndex; i < inputString.Count(); i++)
            {
                if (inputString[i].StartsWith("eye"))
                {
                    tmpPos = ParseVector3(inputString[i]);
                }
                else if (inputString[i].StartsWith("up"))
                {
                    tmpUp = ParseVector3(inputString[i]);
                }
                else if (inputString[i].StartsWith("rotXYZ"))
                {
                    tmpDir = ParseVector3(inputString[i]);
                }
                else if (inputString[i].StartsWith("v_fov"))
                {
                    tmpV_FOV = strToDouble(inputString[i]);
                }
                else if (inputString[i].StartsWith("h_fov"))
                {
                    tmpH_FOV = strToDouble(inputString[i]);
                }
                else if (inputString[i].StartsWith("near_clipping_plane"))
                {
                    tmpNear_clipping_plane = strToDouble(inputString[i]);
                }
                else if (inputString[i].StartsWith("far_clipping_plane"))
                {
                    tmpFar_clipping_plane = strToDouble(inputString[i]);
                }
                else if (inputString[i].StartsWith("aspect_ratio"))
                {
                    tmpAspect_ratio = strToDouble(inputString[i]);
                }
                else if (inputString[i].StartsWith("frame"))
                {
                    break;
                }
                else if (inputString[i].StartsWith("cameras"))
                {
                    break;
                }
                else if (inputString[i].StartsWith("name"))
                {
                    break;
                }
            }
            
            return temp = new CameraFromBinary(tmpPos, tmpDir, tmpV_FOV, tmpAspect_ratio, tmpNear_clipping_plane, tmpFar_clipping_plane);
        }
    }
    }
