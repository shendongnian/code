    using System;
    using System.Timers;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using PIC18F_Servo_Control_V2;
    
    namespace FSI_Grid1
    {
        public partial class Form1 : Form
        {
            TabControl LeftControlTab;
            System.Timers.Timer myTimer;
            public delegate void UpdateStatusBarDelegate();
    
            TabPage myTabPage;
            Grid myGrid;
            serialConnection myConnection;
            int timerDelay = 100;
            int initialX, initialY, currentX, currentY, minX, minY, maxX, maxY;
            int MouseCurrentX, MouseCurrentY, MouseMovedX, MouseMovedY;//tracking mousemovement
            int offsetX, offsetY;//how much each arrow click moves the servos
            bool trackingActive;//are we in tracking mode?
            bool MouseMovedFlag;
            int YOffsetValue;//used to offset dynamically generated buttons in tab groups
            int XCenter, YCenter;
    
            enum States { Startup, MouseTracking, KeyboardTracking, Script, Idle };//state engine
            States CurrentState;
    
            public Form1()
            {
                currentX = initialX = 63503;
                currentY = initialY = 64012;
                minX = 62000;
                maxX = 65000;
                minY = 62000;
                maxY = 65000;
                offsetX = 10;
                offsetY = 10;
                trackingActive = false;
                YOffsetValue = 0;
                CurrentState = States.Startup;
                MouseMovedFlag = false;
    
                myTimer = new System.Timers.Timer(timerDelay);
                myTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                myTimer.Elapsed += new ElapsedEventHandler(TrackMouse);
                myTimer.Enabled = false;
    
                InitializeComponent();
                InitializeGrid();
                InitializeLeftControlTab();
                InitializeSerial();
    
                //Initialize StatusBar
    
                RadioButton button = (RadioButton)this.Controls.Find("SelectKeyboardRadioButton", true)[0];
                button.Checked = true;
    
                activeStatus.Text = "Keyboard Tracking DEACTIVATED";
                activeStatus.BackColor = Color.Red;
                ConnectionStatus.Text = "Disconnected!";
                xOffsetStatus.Text = "X offset value " + offsetX.ToString();
                yOffsetStatus.Text = "Y offset value " + offsetY.ToString();
                //this.MouseMove += new MouseEventHandler(Form_MouseMove);
    
                XCenter = this.Location.X + this.Width / 2;
                YCenter = this.Location.Y + this.Height / 2;
            }
    
            ~Form1()
            {
                if (myConnection.connected)
                    myConnection.disconnect();
            }
    
            private void widthTextBox_KeyPress(object sender, KeyPressEventArgs e)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
    
            private void widthTextBox_KeyUp(object sender, KeyEventArgs e)
            {
                TextBox text = (TextBox)this.Controls.Find("widthTextBox", true)[0];
                xOffsetStatus.Text = text.Text;
                offsetX = Convert.ToInt16(text.Text);
            }
    
            private void heightTextBox_KeyPress(object sender, KeyPressEventArgs e)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
    
            private void heightTextBox_KeyUp(object sender, KeyEventArgs e)
            {
                TextBox text = (TextBox)this.Controls.Find("heightTextBox", true)[0];
                yOffsetStatus.Text = text.Text;
                offsetY = Convert.ToInt16(text.Text);
            }
    
            private void LeftControlTab_DrawItem(object sender, DrawItemEventArgs e)
            {
                Graphics g = e.Graphics;
                Brush _textBrush;
    
                // Get the item from the collection.
                TabPage _tabPage = LeftControlTab.TabPages[e.Index];
    
                // Get the real bounds for the tab rectangle.
                Rectangle _tabBounds = LeftControlTab.GetTabRect(e.Index);
    
                if (e.State == DrawItemState.Selected)
                {
    
                    // Draw a different background color, and don't paint a focus rectangle.
                    _textBrush = new SolidBrush(Color.Red);
                    g.FillRectangle(Brushes.White, e.Bounds);
                }
                else
                {
                    _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                    g.FillRectangle(Brushes.LightGray, e.Bounds);
                    //e.DrawBackground();
                }
    
                // Use our own font.
                Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);
    
                // Draw string. Center the text.
                StringFormat _stringFlags = new StringFormat();
                _stringFlags.Alignment = StringAlignment.Center;
                _stringFlags.LineAlignment = StringAlignment.Center;
                g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
    
            }
    
            private void InitializeLeftControlTab()
            {
                LeftControlTab = new TabControl();
    
                LeftControlTab.Location = new Point(10, 30);
                LeftControlTab.Size = new Size(300, 500);
                LeftControlTab.Alignment = TabAlignment.Left;
                LeftControlTab.SizeMode = TabSizeMode.Fixed;
                LeftControlTab.ItemSize = new Size(30, 90);
                LeftControlTab.DrawMode = TabDrawMode.OwnerDrawFixed;
                
                /*EVENT HANDLER*/
    
                LeftControlTab.DrawItem += new DrawItemEventHandler(LeftControlTab_DrawItem);
    
                /*TABS*/
    
                
                int offset = 100; //how far to the right the edit boxes are
                myTabPage = new TabPage();
                myTabPage.Text = "Appearance";
                LeftControlTab.Controls.Add(myTabPage);
    
                myTabPage = new TabPage();
                myTabPage.Text = "Settings";
                
                /*LABEL*/
    
                Label OffsetLabel = new Label();
                OffsetLabel.Text = "Step resolution";
                OffsetLabel.Location = new Point(0,YOffset());
                myTabPage.Controls.Add(OffsetLabel);
    
                /*WIDTH LABEL*/
    
                Label widthLabel = new Label();
                widthLabel.Text = "Width";
                widthLabel.Location = new Point(0, YOffset());
                myTabPage.Controls.Add(widthLabel);
    
                /*WIDTH TEXTBOX*/
    
                TextBox widthTextBox = new TextBox();
                widthTextBox.Name = "widthTextBox";
                widthTextBox.Text = myGrid.Width.ToString();
                widthTextBox.Location = new Point(widthLabel.Location.X + offset, widthLabel.Location.Y);
                myTabPage.Controls.Add(widthTextBox);
    
    
                widthTextBox.KeyPress += new KeyPressEventHandler(widthTextBox_KeyPress);                             //EVENT HANDLER
                widthTextBox.KeyUp += new KeyEventHandler(widthTextBox_KeyUp);                                    //EVENT HANDLER
                /*HEIGHT LABEL*/
    
                Label heightLabel = new Label();
                heightLabel.Text = "Height";
                heightLabel.Location = new Point(0, YOffset());
                myTabPage.Controls.Add(heightLabel);
    
                /*HEIGHT TEXTBOX*/
    
                TextBox heightTextBox = new TextBox();
                heightTextBox.Name = "heightTextBox";
                heightTextBox.Text = myGrid.Height.ToString();
                heightTextBox.Location = new Point(heightLabel.Location.X + offset, heightLabel.Location.Y);
                myTabPage.Controls.Add(heightTextBox);
    
                /*RADIOBUTTON LABEL*/
    
                GroupBox RadioLabel = new GroupBox();
                RadioLabel.Text = "Tracking Style";
                RadioLabel.Location = new Point(0, YOffset());
                myTabPage.Controls.Add(RadioLabel);
                
                /*RADIO BUTTONS*/
    
                RadioButton SelectMouse = new RadioButton();
                SelectMouse.Location = new Point(10, 20);
                SelectMouse.Text = "Mouse";
                SelectMouse.Name = "SelectMouseRadioButton";
                SelectMouse.CheckedChanged += new EventHandler(RadioButtons_CheckedChanged);
                RadioLabel.Controls.Add(SelectMouse);
    
                RadioButton SelectKeyboard = new RadioButton();
                SelectKeyboard.Location = new Point(10, 42);
                SelectKeyboard.Text = "Keyboard";
                SelectKeyboard.Name = "SelectKeyboardRadioButton";
                SelectKeyboard.CheckedChanged += new EventHandler(RadioButtons_CheckedChanged);
                RadioLabel.Controls.Add(SelectKeyboard);
    
                heightTextBox.KeyPress += new KeyPressEventHandler(heightTextBox_KeyPress);                             //EVENT HANDLER
                heightTextBox.KeyUp += new KeyEventHandler(heightTextBox_KeyUp);                                    //EVENT HANDLER
                //EVENT HANDLER
                LeftControlTab.Controls.Add(myTabPage);
                
                Controls.Add(LeftControlTab);
            }
    
            private void InitializeGrid()
            {
                myGrid = new Grid(offsetX, offsetY);
            }
    
            private void connectToolStripMenuItem_Click(object sender, EventArgs e)
            {
                serialConnectionDialogBox serialBox = new serialConnectionDialogBox();
                Point temp = this.Location;
                temp.X += 30;
                temp.Y += 70;
                serialBox.Location = temp;
                DialogResult results = serialBox.ShowDialog();
                if (results == DialogResult.Yes && !myConnection.connected)
                {
                    myConnection.setCOMMPort(serialBox.commPortComboBox.Text);
                    myConnection.setBaudRate(Convert.ToInt32(serialBox.baudRateComboBox.Text));
                    myConnection.connect();                
                }
                if (myConnection.connected)
                {
                    ConnectionStatus.Text = "X " + currentX.ToString() + "Y " + currentY.ToString();
                }
            }
    
            private void InitializeSerial()
            {
                myConnection = new serialConnection();
    
            }
    
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                bool updatePos = false;
    
                switch (keyData)
                {
                    case Keys.Left:
                        currentX += offsetX;
                        updatePos = true;
                        break;
                    case Keys.Right:
                        currentX -= offsetX;
                        updatePos = true;
                        break;
                    case Keys.Up:
                        currentY += offsetY;
                        updatePos = true;
                        break;
                    case Keys.Down:
                        currentY -= offsetY;
                        updatePos = true;
                        break;
                    case Keys.F5:
                        if (trackingActive)
                        {
                            trackingActive = false;
                            LeftControlTab.Enabled = true;
                            if(CurrentState == States.KeyboardTracking)
                                activeStatus.Text = "Keyboard Tracking DEACTIVATED";
                            if (CurrentState == States.MouseTracking)
                                activeStatus.Text = "Mouse Tracking DEACTIVATED";
                            activeStatus.BackColor = Color.Red;
                            myTimer.Enabled = false;
                        }
                        else
                        {
                            trackingActive = true;
                            LeftControlTab.Enabled = false;
                            if (CurrentState == States.KeyboardTracking)
                                activeStatus.Text = "Keyboard Tracking ACTIVATED";
                            if (CurrentState == States.MouseTracking)
                                activeStatus.Text = "Mouse Tracking ACTIVATED";
                            activeStatus.BackColor = Color.Green;
                            myTimer.Enabled = true;
                        }
                        break;
                }
    
                if (updatePos == true)
                {
                    updatePos = false;
                    Point temp = new Point();
                    temp.X = currentX = clipX(currentX);
                    temp.Y = currentY = clipY(currentY);
                    String tx = "x," + Convert.ToString(temp.X) + ",y," + Convert.ToString(temp.Y) + ",";
                    myConnection.sendData(tx);
                    ConnectionStatus.Text = "X " + currentX.ToString() + "Y " + currentY.ToString();
                }
    
                return base.ProcessCmdKey(ref msg, keyData);
            }
    
            private void disconnectToolStripMenuItem_Click_1(object sender, EventArgs e)
            {
                if (myConnection.connected)
                {
                    myConnection.disconnect();
                    ConnectionStatus.Text = "Disconnected!";
                }
            }
    
            private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
           if (sender == (RadioButton)this.Controls.Find("SelectMouseRadioButton", true)[0])
           {
                CurrentState = States.MouseTracking;
                activeStatus.Text = "Mouse Tracking ";
           }
           if (sender == (RadioButton)this.Controls.Find("SelectKeyboardRadioButton", true)[0])
           {
                CurrentState = States.KeyboardTracking;
                activeStatus.Text = "Keyboard Tracking ";
           }
           if (trackingActive)
                activeStatus.Text += "ACTIVATED";
           else
                activeStatus.Text += "DEACTIVATED";
    
        }
    
    
            private void TrackMouse(object source, ElapsedEventArgs e)
            {
                if (trackingActive && CurrentState == States.MouseTracking)
                {
                    MouseMovedFlag = true;
                    MouseMovedX = -1 * (Cursor.Position.X - XCenter);
                    MouseMovedY = -1 * (Cursor.Position.Y - YCenter);
    
                    currentX += MouseMovedX;
                    currentX = clipX(currentX);
                    currentY += MouseMovedY;
                    currentY = clipY(currentY);
    
                    statusStrip1.Invoke(new UpdateStatusBarDelegate(this.UpdateStatusBar), null);
    
                    Cursor.Position = new Point(XCenter, YCenter);
                }
            }
    
            private int clipX(int tempX)
            {
                if(tempX < minX)
                    tempX = minX;
    
                if(tempX > maxX)
                    tempX = maxX;
                return tempX;
            }
    
            private int clipY(int tempY)
            {
                if(tempY < minY)
                    tempY = minY;
    
                if (tempY > maxY)
                    tempY = maxY;
    
                return tempY;
            }
            private int YOffset()
            {
                int tempValue = YOffsetValue;
                if (tempValue == 0)
                {
                    YOffsetValue += 22;
                    return tempValue;
                }
                else
                {
                    YOffsetValue += 22;
                    return tempValue;
                }
            }
    
            void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                if (true)
                {
                    if (MouseMovedFlag || trackingActive)
                    {
                        Point temp = new Point();
                        temp.X = currentX;
                        temp.Y = currentY;
    
                        String tx = "x," + Convert.ToString(temp.X) + ",y," + Convert.ToString(temp.Y) + ",";
                        myConnection.sendData(tx);
                    }
                }
            }
    
            void UpdateStatusBar()
            {
                ConnectionStatus.Text = "X " + currentX.ToString() + "Y " + currentY.ToString();
                ConnectionStatus.Invalidate();
                this.Update();
            }
        }
    }
