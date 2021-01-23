            string text = "MASTER CARD 4.5.2012";
            string[] split = text.Split(' ');
            string mc = "";
            string date = ""; //when you get this value, you can easily convert to date if you need it
            foreach (string str in split)
            {
                if (char.IsNumber(str[0]))
                {
                    date = str;
                    mc = mc.Remove(mc.Length - 1, 1);
                }
                else
                    mc += str + " ";
            }
