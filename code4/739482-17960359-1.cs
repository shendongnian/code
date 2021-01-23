                //set variables
                string myAssembly = "Test.Assembly";
                string resourceItem = "resources/myimage.png";
                //get the stream
                using (var bSteam = GetResourceStream(string.Format("pack://application:,,,/{0};component//{1}", myAssembly, resourceItem)))
                {
                    //covert the stream to a memory stream and return the byte array
                    using (var ms = new MemoryStream())
                    {
                        bSteam.CopyTo(ms);
                        return ms.ToArray();
                    }
                }
