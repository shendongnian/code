    private bool IsValidPassword(string password)
    {
        return (password.Length > 8 &&
            password.Any(char.IsUpper) &&
            password.Any(char.IsLower) &&
            password.Any(char.IsSymbol)
            );
    }
