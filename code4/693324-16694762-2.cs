    namespace CodeTester
    {
    
       
        public partial class MainWindow : Window
        {    
            string ChartOutput = "";
            public MainWindow()
            {
                InitializeComponent();
                
                //initialize new chart object
                var charts = new[]
             {
                new             
                { 
                      MRN= 745654, 
    
                      Encounters = new int?[]
                      {
                        10,11,12 
                      }, 
                     
                      DocumentIDs = new int?[][]
                      { 
                          new int?[]{110, 1101}, null, new int?[] { 112 }
                      }, 
                      
                      DocumentTypes = new string[][]
                      {
                          new string[]{ "Consents", "H&P"}, null,  new string[] 
                          { "Intake Questionnaire" }
                      }, 
                      
                      DocumentNames = new string[][]
                      { 
                          new string[]{ "Eartube Surgery", "Well-Visit Physical"}, 
                          null, new string[] { "Health Survey" }
                      } 
                  }                        
             };
         
                    foreach (var chart in charts)
                    {
                        ChartOutput += "Patient MRN#: " +  chart.MRN.ToString() +
                        " Has the following visits: " 
                       + Environment.NewLine + Environment.NewLine ; 
                            
                            for(int i =0; i< chart.Encounters.Length; i++)
                            {
                                ChartOutput += "Visit Number: " +
                               chart.Encounters[i].ToString() + Environment.NewLine;
    
                                if (chart.DocumentIDs[i] != null)
                                {
                                    for (int j = 0; j < chart.DocumentIDs[i].Length; j++)
                                        {
                                            ChartOutput += "    Document ID:" +  
                                            chart.DocumentIDs[i][j].ToString() + 
                                            Environment.NewLine + 
                                            "    Document Type: " + 
                                            chart.DocumentTypes[i][j].ToString() + 
                                            Environment.NewLine + 
                                            "    Document Name: " + 
                                            chart.DocumentNames[i][j].ToString() + 
                                            Environment.NewLine + 
                                            Environment.NewLine;                                     
                                        }                                        
                                }
    
                                else { ChartOutput += "    Has No Documents" +
                                Environment.NewLine + Environment.NewLine; }
                            }
                        
                    }
            
            }
                   
            private void Run_Click(object sender, RoutedEventArgs e)
            {  
                MessageBox.Show(ChartOutput);            
            }
        }
    }
    // ChartObject Class
    
    namespace CodeTester
    {
        public class ChartObject
        {
            public ChartObject()
            {
                RecordClass = "Medical";
            }
    
            public string RecordClass { get; private set; }
            public int MRN { get; set; }
            public int[] Encounters { get; set; }
            public int?[][] DocumentIDs { get; set; }
            public string[][] DocumentTypes { get; set; }
            public string[][] DocumentNames { get; set; }
        
        }
    }
