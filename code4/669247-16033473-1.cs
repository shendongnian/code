    public partial class EditReport : Window
    {
            public List<ReportFiles> listabove = new List<ReportFiles>();
    
     public class ReportFiles
        {
            public string RealName { get; set; }
            public string TargetName { get; set; }
        }
    
    	private void buttonAttach_Click(object sender, RoutedEventArgs e)
            {
           	Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                  if (dlg.ShowDialog() == true)
           	{
    foreach (string str in dlg.FileNames)
                         {
                         ReportFiles list = new ReportFiles();
                         list.RealName = str;
                         list.TargetName = filename;
                         dataGrid1.Items.Add(new { RealName = list.RealName, TargetName = list.TargetName });
    			string fileName = @"C:\Temp\" + filename + System.IO.Path.GetExtension(str).Trim(); ;
                        if (File.Exists(fileName))
                        continue;
                        else
                            {
                            try
                            {
                                 File.Copy(str, fileName);
                            }
                            catch (Exception err)
                                 {
                                 MessageBox.Show(err.Message);
                                 return;
                                 }
                            }
    			}
    		}
    }
    
    private void btnSave_Click(object sender, RoutedEventArgs e)
           {
                ReportFiles rep = new ReportFiles();
                DataRowView paths = (System.Data.DataRowView)dataGrid1.Items[0];
                rep.RealName = Convert.ToString(paths.Row.ItemArray[0]);
                
           }
    }
