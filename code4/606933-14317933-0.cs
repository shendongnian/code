    static unsafe string TrimInternal(string input)
    {
        var length = input.Length;
        var array = stackalloc char[length];
        fixed (char* fix = input)
        {
            var ptr = fix;
            var counter = 0;
            var lastWasSpace = false;
            while (*ptr != '\x0')
            {
                //Current char is a space?
                var isSpace = *ptr == ' ';
                //If it's a space but the last one wasn't
                //Or if it's not a space
                if (isSpace && !lastWasSpace || !isSpace)
                    //Write into the result array
                    array[counter++] = *ptr;
                //The last character (before the next loop) was a space
                lastWasSpace = isSpace;
                //Increase the pointer
                ptr++;
            }
            return new string(array, 0, counter);
        }
    }
