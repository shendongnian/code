        [DllImport("user32.dll")]
        static extern short VkKeyScan(char ch);
        public static List<Keys> FromCharacterToKeys(char c)
        {
            var key = BitConverter.GetBytes(VkKeyScan(c));
            if (key[1] > 0)
            {
                var list = new List<Keys> {(Keys) key[0]};
                list.AddRange(ConvertModifierByte(key[1]));
                return list;
            }
            else
            {
                return new List<Keys> { (Keys)key[0] }; 
            }    
        }
        private static List<Keys> ConvertModifierByte(byte modifier)
        {
            switch ((short)modifier)
            {
                case 1:
                    return new List<Keys> { Keys.Shift };
                case 2:
                    return new List<Keys> { Keys.Control };
                case 4:
                    return new List<Keys> { Keys.Alt };
                case 6:
                    return new List<Keys> { Keys.Control, Keys.Alt };
                default:
                    return new List<Keys> { Keys.None };
            }
        }
