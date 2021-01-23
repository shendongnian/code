            public byte[] decode(String str)
            {
                String binary_str = "";
                char[]chars = str.ToCharArray();
                int i=0;
                for(;i<chars.Length && chars[i]!=padding;++i)
                {
                    int index = indexOf(chars[i]);
                    String bin_of_index = DecimalToBinary(index,6);
                    binary_str = binary_str + bin_of_index;
                }
                binary_str = binary_str.Substring(0,binary_str.Length - (2*(chars.Length-i)));
                byte[]bytes=new byte[binary_str.Length/8];
                for(i = 0 ; i < binary_str.Length ; i = i+8)
                {
                    String bin_str = binary_str.Substring(i,8);
                    int char_point = Convert.ToInt16(bin_str,2);
                    bytes[i/8] = (byte) char_point;
                }
                return bytes;
            }
