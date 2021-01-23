             [Serializable]
    class DragBlock
    {
        public string Data
        {
            get;
            set;
        }
    }
    public class DragDropBlock : Panel
    {
        DragBlock Block;
        public DragDropBlock()
            {
                this.MouseDown += new MouseEventHandler(Mouse_Down);
                this.MouseUp += new MouseEventHandler(Mouse_Up);
                Block = new DragBlock()
                {
                    Data = "TEST!"
                };
            }
            void Mouse_Down(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                Clipboard.SetDataObject(new DataObject("DragBlock", Block));
            }
            void Mouse_Up(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                DragBlock newBlock = (DragBlock)Clipboard.GetDataObject().GetData("DragBlock");
                Console.WriteLine(newBlock.Data);
        }
    }
