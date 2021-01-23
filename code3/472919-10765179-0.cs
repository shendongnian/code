            public Color ColorChange(string _color)
        {
            Color _newColor = new Color();
            switch (_color)
            {
                case "Red": _newColor = Color.FromArgb(Color.Red.ToArgb()); break;
                case "Orange": _newColor = Color.FromArgb(Color.Red.ToArgb()); break;
                case "Yellow": _newColor = Color.FromArgb(Color.Yellow.ToArgb()); break;
                case "GreenYellow": _newColor = Color.FromArgb(Color.GreenYellow.ToArgb()); break;
                case "DeepSkyBlue": _newColor = Color.FromArgb(Color.DeepSkyBlue.ToArgb()); break; 
                case "DarkBlue": _newColor = Color.FromArgb(Color.DarkBlue.ToArgb()); break;
                case "Purple": _newColor = Color.FromArgb(Color.Purple.ToArgb()); break;
                case "Black": _newColor = Color.FromArgb(Color.Black.ToArgb()); break;
                case "Gray": _newColor = Color.FromArgb(Color.Gray.ToArgb()); break;
                case "White": _newColor = Color.FromArgb(Color.White.ToArgb()); break;
            }
            return _newColor;
        }
