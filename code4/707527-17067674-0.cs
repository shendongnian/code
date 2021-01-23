    public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
          LoadComboboxes();
        }
    
        public void LoadComboboxes() {
            List<Part> partList = PartDB.GetPartList();
            cboCurPartNum.DataSource = partList;
            cboCurPartNum.SelectedIndex = -1;
            var addEngOrd = false;
            if (addEngOrd  == false) {
              //MessageBox.Show("assign here " + 1);
              cboCurPartNum.SelectedItem = partList[1];
            }
        }
      }
      public static class PartDB {
        static PartDB() {
          PartList = new List<Part> {
            new Part {
              One = 1,
              Two = "unos"
            },
            new Part {
              One = 2,
              Two = "duos"
            }
          };
        }
    
        private static readonly List<Part> PartList;
        public static List<Part> GetPartList() {
          return PartList;
        }
      }
    
      public class Part {
        public int One { get; set; }
        public string Two { get; set; }
      }
    }
