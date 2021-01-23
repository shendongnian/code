    					string[] key = new string[1757600];
				private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
				{
					int val = 0;
					for (int i = 0; i < 26; i++)
					{
						for (int j = 0; j < 10; j++)
						{
							for (int k = 0; k < 26; k++)
							{
								for (int l = 0; l < 10; l++)
								{
									for (int m = 0; m < 26; m++)
									{
										key[val] = (char) (65 + i) + " " + j.ToString() + " " + (char) (65 + k) + " " + l.ToString() + " " +
										      (char) (65 + m);
										//File.AppendAllText("D:\\Codes.txt", key + Environment.NewLine);
										//val = (i + 1)*(j + 1)*(k + 1)*(l + 1)*(m + 1);
										val++;
									}
								}
						backgroundWorker3.ReportProgress(val);
							}
						}
					}
				}
				private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
				{
					MyProgressBar.Value = e.ProgressPercentage;
					MyProgressBar.Text = e.ProgressPercentage.ToString() + "%";
					//if (e.ProgressPercentage == 1757600)
				}
				private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
				{
					File.WriteAllLines("D:\\Codes.txt", key);
					MessageBox.Show("Code generation completed");
				}
