        public int get_char_code(char character){ 
            UTF32Encoding encoding = new UTF32Encoding(); 
            byte[] bytes = encoding.GetBytes(character.ToString().ToCharArray()); 
            return BitConverter.ToInt32(bytes, 0); 
        } 
