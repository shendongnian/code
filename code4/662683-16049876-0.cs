    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace Recycle
    {
      public partial class Form1 : Form
      {
        public int size;
        public LinkedList<string> topRight = new LinkedList<string>();
        public LinkedList<string> bottomLeft = new LinkedList<string>();
        public LinkedList<string> myMatrix = new LinkedList<string>();
        public LinkedList<string> shiftMatrix = new LinkedList<string>();
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            size = int.Parse(textBox2.Text);
            int c = 0;
            int q = 0;
            int w = 0;
            string[] content = new string[size];
            Random rnd = new Random();
            for (c = 0; c < size; c++)
            {
                listView1.Columns.Add("", 25);
            }
            for (q = 0; q < size; q++) 
            {
                for (w = 0; w < size; w++)
                {
                    content[w] = rnd.Next(9,100).ToString();
                }
                ListViewItem lvi = new ListViewItem(content);
                listView1.Items.Add(lvi);
            }
        }
        public bool iseven(int size)
        {
            if (size % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void button1_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count < 3)
            {
                MessageBox.Show("Matrix cannot be rotated.");
                return;
            }
            bool even = false;
            int shift = int.Parse(textBox1.Text); //amount to shift by
            int box = listView1.Items.Count - 1; //size of box
            int half = Convert.ToInt32(listView1.Items.Count / 2);
            int corner = 0; //inside corner of box
            if (shift > listView1.Items.Count)
            {
                shift = shift % ((listView1.Items.Count - 2) * 4);
            }
            do
            {
                eachPass(shift, box, corner);
                ++corner;
                --box;
            } while (box >= half + 1);
        }
        public void eachPass(int shift, int box, int corner)
        {
            int x;
            int i;
            //Read each non-diagonal value into one of two lists
            for (x = corner + 1; x < box; x++)
            {
                topRight.AddLast(listView1.Items[corner].SubItems[x].Text);
            }
            x = box;
            for (i = corner + 1; i < box; i++)
            {
                topRight.AddLast(listView1.Items[i].SubItems[x].Text);
            }
            for (x = box - 1; x  > corner; x--)
            {
                bottomLeft.AddLast(listView1.Items[box].SubItems[x].Text);
            }
            x = corner;
            for (i = box - 1; i > corner; i--)
            {
                bottomLeft.AddLast(listView1.Items[i].SubItems[x].Text);
            }
            string myTest = "";
            //join the two lists, so they can be shifted
            foreach (string tR in topRight)
            {
                myMatrix.AddLast(tR);
            }
            foreach (string bL in bottomLeft)
            {
                myMatrix.AddLast(bL);
            }
            int sh;
            //shift the list using another list
            for (sh = shift; sh < myMatrix.Count; sh++)
            {
                shiftMatrix.AddLast(myMatrix.ElementAt(sh));
            }
            for (sh = 0; sh < shift; sh++)
            {
                shiftMatrix.AddLast(myMatrix.ElementAt(sh));
            }
            //we need the sizes of the current lists
            int trCnt = topRight.Count;
            int blCnt = bottomLeft.Count;
            //clear them for reuse
            topRight.Clear();
            bottomLeft.Clear();
            int s;
            //put the shifted values back
            for (s = 0; s < trCnt; s++)
            {
                topRight.AddLast(shiftMatrix.ElementAt(s));
            }
            for (s = blCnt; s < shiftMatrix.Count; s++)
            {
                bottomLeft.AddLast(shiftMatrix.ElementAt(s));
            }
            int tRn = 0;
            int bLn = 0;
            //write each non-diagonal value from one of two lists
            for (x = corner + 1; x < box; x++)
            {
                listView1.Items[corner].SubItems[x].Text = topRight.ElementAt(tRn);
                ++tRn;
            }
            x = box;
            for (i = corner + 1; i < box; i++)
            {
                listView1.Items[i].SubItems[x].Text = topRight.ElementAt(tRn);
                ++tRn;
            }
            for (x = box - 1; x > corner; x--)
            {
                listView1.Items[box].SubItems[x].Text = bottomLeft.ElementAt(bLn);
                ++bLn;
            }
            x = corner;
            for (i = box - 1; i > corner; i--)
            {
                listView1.Items[i].SubItems[x].Text = bottomLeft.ElementAt(bLn);
                ++bLn;
            }
            myMatrix.Clear();
            shiftMatrix.Clear();
            topRight.Clear();
            bottomLeft.Clear();
        }
      }
    }
