    public static String Decode(string Path)
        {
            String text;
            using (StreamReader sr = new StreamReader(Path))
            {
                    text = st.ReadToEnd();
                    byte[] bytes = Convert.FromBase64String(text);
                    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                    System.Text.Decoder decoder = encoder.GetDecoder();
                    int count = decoder.GetCharCount(bytes, 0, bytes.Length);
                    char[] arr = new char[count];
                    decoder.GetChars(bytes, 0, bytes.Length, arr, 0);
                    text= new string(arr);
                    
                    return text;
            }
        }
