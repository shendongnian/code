    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace PalisadeWorld
    {   
    //struct to store all the positions of each matched panel size in an array 'Identities'
    struct ID
        {
            public int[] Identities;
            public ID(int[] widths, int rows)
            {   
                //Column1 from spreadsheet
                int[] allWidths = { 300, 305, 310, 315, 320, 325, 330, ..., 5000 };
                int i,j;
                int[] Ids = new int[rows];
    
                for (i = 0; i < rows; i++)
                {
                    for (j = 0; j < 941; j++)
                    {
                        if (widths[i] == allWidths[j])
                        {
                            Ids[i] = j;
                            break;
                        }
                    }
                }
                this.Identities = Ids;
            }
            public override string ToString()
            {
                string data = String.Format("{0}", this.Identities);
                return data;
            }
        }
    
    class LookUpSheet
    {   
        //retrieve user input from another class
        public int[] lookUp_Widths {get; set;}
        public int lookUp_Rows { get; set; }
    
        //Method returning values from Column2
        public int[] GetNumPales1()
        {
            int[] all_numPales = { 2, 2, 2, 2, 2, 2, 2, 2, 2, ..."goes on till [941]"...};
            int[] numPales = new int[lookUp_Rows];
    
            ID select = new ID(lookUp_Widths, lookUp_Rows);
    
            for (int i = 0; i < lookUp_Rows; i++)
            {
                numPales[i] = all_numPales[select.Identities[i]];
            }
    
            return numPales;
        }
        //Method returning values from Column3
        public int[] GetBlocks1()
        {
            int[] all_blocks = { 56, 59, 61, 64, 66, 69, 71, 74, "goes on till [941]"...};
            int[] blocks = new int[lookUp_Rows];
    
            ID select = new ID(lookUp_Widths, lookUp_Rows);
    
            for (int i = 0; i < lookUp_Rows; i++)
            {
                blocks[i] = all_blocks[select.Identities[i]];
            }
            return blocks;
        }
