    string dirty=@"tfgtf$@$%gttg%$% 664%$";
    string clean = dirty.Clean();
        public static string Clean(this String name)
        {
            var namearray = new Char[name.Length];
 
            var newIndex = 0;
            for (var index = 0; index < namearray.Length; index++)
            {
                var letter = (Int32)name[index];
 
                if (!((letter > 96 && letter < 123) || (letter > 64 && letter < 91) || (letter > 47 && letter < 58)))
                    continue;
 
                namearray[newIndex] = (Char)letter;
                ++newIndex;
            }
 
            return new String(namearray).TrimEnd();
        }
