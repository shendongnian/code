        // ...
        var nextChar = new char[4];  // 2 might suffice
        for (var i = startPos; i < bytesRead; i++)
        {
            int charCount;
            //...
            charCount = decoder.GetChars(buffer, i, 1, nextChar, 0);
            if (charCount == 0)
            {
                bytesSkipped++;
                continue;
            }
            for (int ic = 0; ic < charCount; ic++)
            {
                char c = nextChar[ic];
                charPos++;
                // Process character here...
            }
        }
