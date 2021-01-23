    namespace MyCustomVisualizer
    {
        public class MyObjectSource : VisualizerObjectSource
        {
            public override void GetData(object target, Stream outgoingData)
            {
                try
                {
                    byte[] byteArray = JsonHelper.Serialize(target);
                    outgoingData.Write(byteArray, 0, byteArray.Length);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "VisualizerObjectSource Error");
                }
            }
        }
    
        public class MyVisualizer : DialogDebuggerVisualizer
        {
            override protected void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
            {
                try
                {
                    string _str = null;
                    Stream _stream = objectProvider.GetData();
    
                    if (_stream != null && _stream.Length > 0)
                    {
                        object _obj = null;
                        _obj = JsonHelper.Deserialize(_stream); // Here i get the object i want
                        // ^^^
                        // Now add ur code to visualize the object in your way.
                        
                        /* This is only to verify the object data before visualizing.
                        if (_obj != null)
                        {
                            _str = JsonHelper.ObjectToString(_obj);
                            MessageBox.Show(_str, "Show");
                        }
                        */
                    }
    
                    // Show the grid with the list
                    windowService.ShowDialog();
                }
                catch (Exception exp) { MessageBox.Show(exp.Message, "Visualizer Error"); }
                finally
                {
                }
            }
        }
    
        #region JsonHelper Class
        public static class JsonHelper
        {
            public static byte[] Serialize(object _Object)
            {
                MemoryStream _MemoryStream = new MemoryStream();
                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.TypeNameHandling = TypeNameHandling.Auto;
    
                try
                {
                    using (StreamWriter sw = new StreamWriter(_MemoryStream))
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, _Object);
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Serialize Error");
                }
                return _MemoryStream.ToArray();
            }
    
            public static object Deserialize(Stream _ByteArray)
            {
                Object _object = new Object();
                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.TypeNameHandling = TypeNameHandling.Auto;
                try
                {
                    StreamReader sw = new StreamReader(_ByteArray);
                    JsonReader reader = new JsonTextReader(sw);
                    _object = serializer.Deserialize(reader);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Deserialize Error");
                }
                return _object;
            }
    
            public static string ObjectToString(object _object)
            {
                string _str = string.Empty;
                JsonSerializerSettings _jsonSerializeSettings = new JsonSerializerSettings();
                _jsonSerializeSettings.NullValueHandling = NullValueHandling.Ignore;
                _jsonSerializeSettings.TypeNameHandling = TypeNameHandling.Auto;
                _str = JsonConvert.SerializeObject(_object, Newtonsoft.Json.Formatting.Indented, _jsonSerializeSettings);
                return _str;
            }
        }
        #endregion
    
    }
