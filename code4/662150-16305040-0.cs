    const int spacing = 30;  //ruimte tussen kotjes
                    int aantal = (int)nudColsPerBlock.Value * (int)nudRowsPerBlock.Value; //totaal aantal kotjes per rij/kolom
                    Label[][] SudokuRaster = new Label[aantal][];
                    for (int x = 0; x < aantal; x++)
                    {
                        SudokuRaster[x] = new Label[aantal];
                        for (int y = 0; y < aantal; y++)
                        {
                            SudokuRaster[x][y] = new Label();
                            SudokuRaster[x][y].BorderStyle = BorderStyle.FixedSingle;
                            SudokuRaster[x][y].Location = new System.Drawing.Point(x * spacing, y * spacing);
                        SudokuRaster[x][y].Name = "Sudoku" + x.ToString() + "," + y.ToString();
                        SudokuRaster[x][y].Size = new Size(spacing, spacing);
                        SudokuRaster[x][y].TabIndex = 0;
                        SudokuRaster[x][y].MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick);
                       
                    }
                    this.Controls.AddRange(SudokuRaster[x]);
                }
