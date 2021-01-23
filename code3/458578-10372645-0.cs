            var inputText = tb.Text;
            if (inputText.Length == 2)
            {
                var escaped = System.Text.RegularExpressions.Regex.Unescape(inputText);
                if (escaped.Length == 1)
                {
                    var character = escaped.ToCharArray()[0];
                    if (char.IsControl(character))
                    {
                        inputText = character.ToString();
                    }
                }
            }
