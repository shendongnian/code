    using System;
    using System.Collections.Generic; // # Necessary for IList<int>
    using System.Linq; // # Necessary for IList<int>.ToArray()
    
    /// <summary>
    /// Returns all indexes of the specified <paramref name="value"/> in the current string.
    /// </summary>
    /// <param name="@this">The current string this method is operating on.</param>
    /// <param name="value">The value to be searched.</param>
    /// <returns><c>Null</c>, if <paramref name="value"/> is <c>null</c> or empty.
    /// An array holding all indexes of <paramref name="value"/> in this string,
    /// else.</returns>
    static int[] IndexesOf(this string @this, string value)
    {
        // # Can't search for null or string.Empty, you can return what
        //   suits you best
        if (string.IsNullOrEmpty(value))
            return null;
        
        // # Using a list instead of an array saves us statements to resize the 
        //   array by ourselves
        IList<int> indexes = new List<int>();
        int startIndex = 0;
    
        while (startIndex < @this.Length)
        {
            startIndex = @this.IndexOf(value, startIndex);
            if (startIndex >= 0)
            {
                // # Add the found index to the result and increment it by length of value
                //   afterwards to keep searching AFTER the current position
                indexes.Add(startIndex);
                startIndex += value.Length;
            }
            else
            {
                // # Exit loop, if value does not occur in the remaining string
                break;
            }
        }
        
        // # Return an array to conform with other string operations.
        return indexes.ToArray();
    }
    
    /// <summary>
    /// Returns the indexes of the <paramref name="n"/>th occurrence of the specified
    /// <paramref name="value"/> in the current string.
    /// </summary>
    /// <param name="@this">The current string this method is operating on.</param>
    /// <param name="value">The value to be searched.</param>
    /// <param name="n">The 1-based nth occurrence.</param>
    /// <returns><c>-1</c>, if <paramref name="value"/> is <c>null</c> or empty -or-
    /// <paramref name="n"/> is less than 1.</returns>
    static int IndexOfNth(this string @this, string value, int n /* n is 1-based */)
    {
        // # You could throw an ArgumentException as well, if n is less than 1
        if (string.IsNullOrEmpty(value) || n < 1)
            return -1;
    
        int[] indexes = @this.IndexesOf(value);
    
        // # If there are n or more occurrences of 'value' in '@this'
        //   return the nth index.
        if (indexes != null && indexes.Length >= n)
        {
            return indexes[n - 1];
        }
        
        return -1;
    }
