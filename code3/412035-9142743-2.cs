    /// <summary> 
    /// Helper class that validates text box input for double values. 
    /// </summary> 
    internal static class TextBoxDoubleValidator 
    { 
        private static readonly ThreadLocal<NumberFormatInfo> _numbersFormat = new ThreadLocal<NumberFormatInfo>( 
            () => Thread.CurrentThread.CurrentCulture.NumberFormat);
    
        /// <summary> 
        /// Returns true if input <param name="text"/> is accepted by IsDouble text box. 
        /// </summary> 
        public static bool IsValid(string text) 
        { 
            // First corner case: null or empty string is a valid text in our case 
            if (text.IsNullOrEmpty()) 
                return true;
    
            // '.', '+', '-', '+.' or '-.' - are invalid doubles, but we should accept them 
            // because user can continue typeing correct value (like .1, +1, -0.12, +.1, -.2) 
            if (text == _numbersFormat.Value.NumberDecimalSeparator || 
                text == _numbersFormat.Value.NegativeSign || 
                text == _numbersFormat.Value.PositiveSign || 
                text == _numbersFormat.Value.NegativeSign + _numbersFormat.Value.NumberDecimalSeparator || 
                text == _numbersFormat.Value.PositiveSign + _numbersFormat.Value.NumberDecimalSeparator) 
                return true;
    
            // Now, lets check, whether text is a valid double 
            bool isValidDouble = StringEx.IsDouble(text);
    
            // If text is a valid double - we're done 
            if (isValidDouble) 
                return true;
    
            // Text could be invalid, but we still could accept such input. 
            // For example, we should accepted "1.", because after that user will type 1.12 
            // But we should not accept "..1" 
            int separatorCount = CountOccurances(text, _numbersFormat.Value.NumberDecimalSeparator); 
                
            // If text is not double and we don't have separator in this text 
            // or if we have more than one separator in this text, than text is invalid 
            if (separatorCount != 1) 
                return false;
    
            // Lets remove first separator from our input text 
            string textWithoutNumbersSeparator = RemoveFirstOccurrance(text, _numbersFormat.Value.NumberDecimalSeparator);
    
            // Second corner case: 
            // '.' is also valid text, because .1 is a valid double value and user may try to type this value 
            if (textWithoutNumbersSeparator.IsNullOrEmpty()) 
                return true;
    
            // Now, textWithoutNumbersSeparator should be valid if text contains only one 
            // numberic separator 
            bool isModifiedTextValid = StringEx.IsDouble(textWithoutNumbersSeparator); 
            return isModifiedTextValid; 
        }
    
        /// <summary> 
        /// Returns number of occurances of value in text 
        /// </summary> 
        private static int CountOccurances(string text, string value) 
        { 
            string[] subStrings = text.Split(new[] { value }, StringSplitOptions.None); 
            return subStrings.Length - 1;
    
        }
    
        /// <summary> 
        /// Removes first occurance of valud from text. 
        /// </summary> 
        private static string RemoveFirstOccurrance(string text, string value) 
        { 
            if (string.IsNullOrEmpty(text)) 
                return String.Empty; 
            if (string.IsNullOrEmpty(value)) 
                return text;
    
            int idx = text.IndexOf(value, StringComparison.InvariantCulture); 
            if (idx == -1) 
                return text; 
            return text.Remove(idx, value.Length); 
        }
    
    }
