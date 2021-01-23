    public static string CancellableReadLine(CancellationToken cancellationToken)
    {
        StringBuilder stringBuilder = new StringBuilder();
        Task.Run(() =>
        {
            try
            {
                ConsoleKeyInfo keyInfo;
                var startingLeft = Con.CursorLeft;
                var startingTop = Con.CursorTop;
                var currentIndex = 0;
                do
                {
                    var previousLeft = Con.CursorLeft;
                    var previousTop = Con.CursorTop;
                    while (!Con.KeyAvailable)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        Thread.Sleep(50);
                    }
                    keyInfo = Con.ReadKey();
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.A:
                        case ConsoleKey.B:
                        case ConsoleKey.C:
                        case ConsoleKey.D:
                        case ConsoleKey.E:
                        case ConsoleKey.F:
                        case ConsoleKey.G:
                        case ConsoleKey.H:
                        case ConsoleKey.I:
                        case ConsoleKey.J:
                        case ConsoleKey.K:
                        case ConsoleKey.L:
                        case ConsoleKey.M:
                        case ConsoleKey.N:
                        case ConsoleKey.O:
                        case ConsoleKey.P:
                        case ConsoleKey.Q:
                        case ConsoleKey.R:
                        case ConsoleKey.S:
                        case ConsoleKey.T:
                        case ConsoleKey.U:
                        case ConsoleKey.V:
                        case ConsoleKey.W:
                        case ConsoleKey.X:
                        case ConsoleKey.Y:
                        case ConsoleKey.Z:
                        case ConsoleKey.Spacebar:
                        case ConsoleKey.Decimal:
                        case ConsoleKey.Add:
                        case ConsoleKey.Subtract:
                        case ConsoleKey.Multiply:
                        case ConsoleKey.Divide:
                        case ConsoleKey.D0:
                        case ConsoleKey.D1:
                        case ConsoleKey.D2:
                        case ConsoleKey.D3:
                        case ConsoleKey.D4:
                        case ConsoleKey.D5:
                        case ConsoleKey.D6:
                        case ConsoleKey.D7:
                        case ConsoleKey.D8:
                        case ConsoleKey.D9:
                        case ConsoleKey.NumPad0:
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.NumPad2:
                        case ConsoleKey.NumPad3:
                        case ConsoleKey.NumPad4:
                        case ConsoleKey.NumPad5:
                        case ConsoleKey.NumPad6:
                        case ConsoleKey.NumPad7:
                        case ConsoleKey.NumPad8:
                        case ConsoleKey.NumPad9:
                        case ConsoleKey.Oem1:
                        case ConsoleKey.Oem102:
                        case ConsoleKey.Oem2:
                        case ConsoleKey.Oem3:
                        case ConsoleKey.Oem4:
                        case ConsoleKey.Oem5:
                        case ConsoleKey.Oem6:
                        case ConsoleKey.Oem7:
                        case ConsoleKey.Oem8:
                        case ConsoleKey.OemComma:
                        case ConsoleKey.OemMinus:
                        case ConsoleKey.OemPeriod:
                        case ConsoleKey.OemPlus:
                            stringBuilder.Insert(currentIndex, keyInfo.KeyChar);
                            currentIndex++;
                            if (currentIndex < stringBuilder.Length)
                            {
                                var left = Con.CursorLeft;
                                var top = Con.CursorTop;
                                Con.Write(stringBuilder.ToString().Substring(currentIndex));
                                Con.SetCursorPosition(left, top);
                            }
                            break;
                        case ConsoleKey.Backspace:
                            if (currentIndex > 0)
                            {
                                currentIndex--;
                                stringBuilder.Remove(currentIndex, 1);
                                var left = Con.CursorLeft;
                                var top = Con.CursorTop;
                                if (left == previousLeft)
                                {
                                    left = Con.BufferWidth - 1;
                                    top--;
                                    Con.SetCursorPosition(left, top);
                                }
                                Con.Write(stringBuilder.ToString().Substring(currentIndex) + " ");
                                Con.SetCursorPosition(left, top);
                            }
                            else
                            {
                                Con.SetCursorPosition(startingLeft, startingTop);
                            }
                            break;
                        case ConsoleKey.Delete:
                            if (stringBuilder.Length > currentIndex)
                            {
                                stringBuilder.Remove(currentIndex, 1);
                                Con.SetCursorPosition(previousLeft, previousTop);
                                Con.Write(stringBuilder.ToString().Substring(currentIndex) + " ");
                                Con.SetCursorPosition(previousLeft, previousTop);
                            }
                            else
                                Con.SetCursorPosition(previousLeft, previousTop);
                            break;
                        case ConsoleKey.LeftArrow:
                            if (currentIndex > 0)
                            {
                                currentIndex--;
                                var left = Con.CursorLeft - 2;
                                var top = Con.CursorTop;
                                if (left < 0)
                                {
                                    left = Con.BufferWidth + left;
                                    top--;
                                }
                                Con.SetCursorPosition(left, top);
                                if (currentIndex < stringBuilder.Length - 1)
                                {
                                    Con.Write(stringBuilder[currentIndex].ToString() + stringBuilder[currentIndex + 1]);
                                    Con.SetCursorPosition(left, top);
                                }
                            }
                            else
                            {
                                Con.SetCursorPosition(startingLeft, startingTop);
                                if (stringBuilder.Length > 0)
                                    Con.Write(stringBuilder[0]);
                                Con.SetCursorPosition(startingLeft, startingTop);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentIndex < stringBuilder.Length)
                            {
                                Con.SetCursorPosition(previousLeft, previousTop);
                                Con.Write(stringBuilder[currentIndex]);
                                currentIndex++;
                            }
                            else
                            {
                                Con.SetCursorPosition(previousLeft, previousTop);
                            }
                            break;
                        case ConsoleKey.Home:
                            if (stringBuilder.Length > 0 && currentIndex != stringBuilder.Length)
                            {
                                Con.SetCursorPosition(previousLeft, previousTop);
                                Con.Write(stringBuilder[currentIndex]);
                            }
                            Con.SetCursorPosition(startingLeft, startingTop);
                            currentIndex = 0;
                            break;
                        case ConsoleKey.End:
                            if (currentIndex < stringBuilder.Length)
                            {
                                Con.SetCursorPosition(previousLeft, previousTop);
                                Con.Write(stringBuilder[currentIndex]);
                                var left = previousLeft + stringBuilder.Length - currentIndex;
                                var top = previousTop;
                                while (left > Con.BufferWidth)
                                {
                                    left -= Con.BufferWidth;
                                    top++;
                                }
                                currentIndex = stringBuilder.Length;
                                Con.SetCursorPosition(left, top);
                            }
                            else
                                Con.SetCursorPosition(previousLeft, previousTop);
                            break;
                        default:
                            Con.SetCursorPosition(previousLeft, previousTop);
                            break;
                    }
                } while (keyInfo.Key != ConsoleKey.Enter);
                Con.WriteLine();
            }
            catch
            {
                //MARK: Change this based on your need. See description below.
                stringBuilder.Clear();
            }
        }).Wait();
        return stringBuilder.ToString();
    }
