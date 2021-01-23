            System.Drawing.Color text_color;
            switch (loggingEvent.Level.DisplayName.ToUpper())
            {
                case "FATAL":
                    text_color = System.Drawing.Color.DarkRed;
                    break;
                case "ERROR":
                    text_color = System.Drawing.Color.Red;
                    break;
                case "WARN":
                    text_color = System.Drawing.Color.DarkOrange;
                    break;
                case "INFO":
                    text_color = System.Drawing.Color.Teal;
                    break;
                case "DEBUG":
                    text_color = System.Drawing.Color.Green;
                    break;
                default:
                    text_color = System.Drawing.Color.Black;
                    break;
            }
            _TextBox.BeginInvoke((MethodInvoker)delegate
            {
                _TextBox.SelectionColor = text_color;
                _TextBox.AppendText(RenderLoggingEvent(loggingEvent));
            });
