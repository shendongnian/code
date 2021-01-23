    private void UnZip(string zipToExtract, string unzipDirectoryl){
                if (this.progressBar1.InvokeRequired)
                {
                    progressBar1.Invoke(new Action(delegate() { UnZip(zipToExtract, unzipDirectoryl); }));
                }
                else if (this.label3.InvokeRequired) // why else if on another control???
                {
                    label3.Invoke(new Action(delegate() { UnZip(zipToExtract, unzipDirectoryl); }));
                }
                else
                {                        ....
                            progressBar1.Value += 1;
                            progressBar1.Refresh(); //why use Refresh()?
                            label3.Text = ((progressBar1.Value * 100) / (progressBar1.Maximum)).ToString();
                            label3.Refresh();
                        ...
                }
            }
