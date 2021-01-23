    public static class Factory 
    { 
        public static Button GetButton(operatingSystem) 
        {
            switch (operatingSystem)
            {
                case "windows":
                    return new WindowsButton();
                case "macintosh":
                    return new MacButton();
            }
        }
    }
