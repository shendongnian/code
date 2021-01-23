    void validateInput(char x)
    {
       if (((int)x >= 65 && (int)x <= 90 ) || ((int)x >= 97 && (int)x <= 122))
            {
                storedChar = x;
            }
            else
            {
                throw new SomeException();
            }
    }
