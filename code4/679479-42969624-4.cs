    using System.Data.OleDb;
    using System.IO;
    using System.Text.RegularExpressions;
    private void btopen_Click(object sender, EventArgs e)
    {
       try
       {
         OpenFileDialog openFileDialog1 = new OpenFileDialog();  //create openfileDialog Object
         openFileDialog1.Filter = "XML Files (*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) |*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb";//open file format define Excel Files(.xls)|*.xls| Excel Files(.xlsx)|*.xlsx| 
         openFileDialog1.FilterIndex = 3;
    
         openFileDialog1.Multiselect = false;        //not allow multiline selection at the file selection level
         openFileDialog1.Title = "Open Text File-R13";   //define the name of openfileDialog
         openFileDialog1.InitialDirectory = @"Desktop"; //define the initial directory
   
         if (openFileDialog1.ShowDialog() == DialogResult.OK)        //executing when file open
         {
           string pathName = openFileDialog1.FileName;
           fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
           DataTable tbContainer = new DataTable();
           string strConn = string.Empty;
           string sheetName = fileName;
                    
           FileInfo file = new FileInfo(pathName);
           if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
           string extension = file.Extension;
           switch (extension)
           {
              case ".xls":
                       strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                       break;
              case ".xlsx":
                       strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                       break;
              default:
                       strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                       break;
             }
             OleDbConnection cnnxls = new OleDbConnection(strConn);
             OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheetName), cnnxls);
             oda.Fill(tbContainer);
                    
             dtGrid.DataSource = tbContainer;
           }
                
         }
         catch (Exception)
         {
            MessageBox.Show("Error!");
         }
      }
