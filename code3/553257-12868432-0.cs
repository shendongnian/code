        const int HeaderLength = 2;
        const int UsernameMaxLength = 16;
        const int PasswordMaxLength = 16;
        public static byte[] CreatePacket(int header, string username, string password)//I assume the header's some kind of record ID?
        {
            int messageLength = UsernameMaxLength + PasswordMaxLength + HeaderLength;
            StringBuilder sb = new StringBuilder(messageLength+ 2);
            sb.Append((char)messageLength);
            sb.Append(char.MinValue);
            sb.Append((char)header);
            sb.Append(char.MinValue);
            sb.Append(username.PadRight(UsernameMaxLength, char.MinValue));
            sb.Append(password.PadRight(PasswordMaxLength, char.MinValue));
            return Encoding.ASCII.GetBytes(sb.ToString()); 
        }
