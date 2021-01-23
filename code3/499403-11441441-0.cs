    private void CanvasMouseMove(object sender, MouseEventArgs e)
            {
                double xPos = e.GetPosition(m_Grid).X;
                double yPos = e.GetPosition(m_Grid).Y;
    
                Line vertLine = new Line
                                    {
                                        Name = "vertLine",
                                        X1 = xPos,
                                        Y1 = 0,
                                        X2 = xPos,
                                        Y2 = m_Grid.Height,
                                        Stroke = Brushes.Black,
                                        StrokeThickness = 1
                                    };
    
                Line horzLine = new Line
                                    {
                                        Name = "horzLine",
                                        X1 = 0,
                                        Y1 = yPos,
                                        X2 = m_Grid.Width,
                                        Y2 = yPos,
                                        StrokeThickness = 1,
                                        Stroke = Brushes.Black
                                    };
    
                m_Grid.Children.Remove((Line) m_Grid.Children.OfType<Line>().FirstOrDefault(x => x.Name == "vertLine"));
                m_Grid.Children.Remove((Line) m_Grid.Children.OfType<Line>().FirstOrDefault(x => x.Name == "horzLine"));
    
                m_Grid.Children.Add(vertLine); //m_Grid is my Canvas
                m_Grid.Children.Add(horzLine);
    
                m_Grid.UpdateLayout();
            }
