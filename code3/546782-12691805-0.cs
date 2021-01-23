    	public void Write(string text)
		{
			CreateOutputPane(Name); // Creates the OutputWindowPane if it does not already exist.
			if (_outputWindowPane != null)
			{
                try
				{
					_outputWindowPane.Activate();
                    _outputWindowPane.OutputString(text);
				}
                catch (Exception ex1)
				{
					System.Diagnostics.Debug.WriteLine("Exception writing text '" + text + "': " + ex1.ToString());
                    // Exceeded maximum output pane size?
					try
					{
						_outputWindowPane.Clear();
						_outputWindowPane.OutputString(text);
					}
					catch (Exception ex2)
					{
						System.Diagnostics.Debug.WriteLine("Exception writing text '" + text + "': " + ex2.ToString());
					}
				}
			}
		}
