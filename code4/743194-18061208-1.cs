           var lines = File.ReadAllLines( path )
                        .Select( s => s.Trim( ) )
                        .Where( s => s.Length > 0 ).ToArray( );
            int index = 0;
            void Next() { index++; }
            bool Peek(string token ) { return lines[index].StartsWith( token ) ;}
            string ReadStringValue  ( ) { 
               var value = lines[index].Split( ' ' )[1]; 
               Next( ); 
               return value; 
            };
            string ReadIntValue () { 
              var value = lines[index].Split( ' ' )[1]; 
              Next( ); 
              return int.Parse(value); 
            };
            Header ReadAnimation() {
               var anim= new Animation();
               while (index<lines.Length)
               {
                   if (Peek("num_frames")) anim.NuMFrames = ReadIntValue();
                   if (Peek("start")) ....
                   if (Peek("frame")) anim.AddFrame( ReadFrame() );
               }
 
            }
            Frame ReadFrame() {
               if (Peek("frame")) {
                  var frame = new Frame();
                  frame.Index = ReadIntValue();
                  ReadMeshes( frame );
                  ReadCameras( frame );                  
                  return frame;
               }
               return null;
            }
            void ReadMeshes(Frame frame)
            {
                if (Peek("meshes")) {
                    int count = ReadIntValue();
                    for (int i =0; i<count; i++) {
                        frame.Meshes.Add( ReadMesh() );
                    }
                }
            }
            Mesh ReadMesh() {
               ....
            }
            
           
            
 
