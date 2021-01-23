        //
        // Summary:
        //     Returns a new string in which all the characters in the current instance,
        //     beginning at a specified position and continuing through the last position,
        //     have been deleted.
        //
        // Parameters:
        //   startIndex:
        //     The zero-based position to begin deleting characters.
        //
        // Returns:
        //     A new string that is equivalent to this string except for the removed characters.
        //
        // Exceptions:
        //   System.ArgumentOutOfRangeException:
        //     startIndex is less than zero.-or- startIndex specifies a position that is
        //     not within this string.
        public string Remove(int startIndex);
