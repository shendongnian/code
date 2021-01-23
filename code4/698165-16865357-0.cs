       public NewSchedule2(string path)
        {
            InitializeComponent();
            this.SuspendLayout();
    
            labels = new System.Windows.Forms.Label[7];
            exercises = new System.Windows.Forms.TextBox[7];
            sets = new System.Windows.Forms.TextBox[7];
            reps = new System.Windows.Forms.TextBox[7];
            addToDay = new System.Windows.Forms.Button[7];
    
            string[] lines = File.ReadAllLines(path);
    
            for (int i = 0; i < 7; i++)
            {
                this.labels[i] = new System.Windows.Forms.Label();
                this.labels[i].Location = new System.Drawing.Point(40, 40 + i * 50);
                this.labels[i].Name = "Label" + i;
                this.labels[i].Size = new System.Drawing.Size(110, 20);
                this.labels[i].Text = lines[i];
                this.Controls.Add(this.labels[i]);
    
                if (lines[i] == "Restday")
                {
    
                }
                else
                {
                    this.exercises[i] = new System.Windows.Forms.TextBox();
                    this.exercises[i].Location = new System.Drawing.Point(160, 40 + i * 50);
                    this.exercises[i].Name = "excersiceBox" + i;
                    this.exercises[i].Size = new System.Drawing.Size(110, 20);
                    this.exercises[i].Text = "";
                    this.Controls.Add(this.exercises[i]);
    
                    this.sets[i] = new System.Windows.Forms.TextBox();
                    this.sets[i].Location = new System.Drawing.Point(290, 40 + i * 50);
                    this.sets[i].Name = "setBox" + i;
                    this.sets[i].Size = new System.Drawing.Size(40, 20);
                    this.sets[i].Text = "";
                    this.Controls.Add(this.sets[i]);
    
                    this.reps[i] = new System.Windows.Forms.TextBox();
                    this.reps[i].Location = new System.Drawing.Point(350, 40 + i * 50);
                    this.reps[i].Name = "repBox" + i;
                    this.reps[i].Size = new System.Drawing.Size(40, 20);
                    this.reps[i].Text = "";
                    this.Controls.Add(this.reps[i]);
    
                    this.addToDay[i] = new System.Windows.Forms.Button();
                    this.addToDay[i].Location = new System.Drawing.Point(430, 40 + i * 50);
                    this.addToDay[i].Name = "addToDay" + i;
                    this.addToDay[i].Click += new System.EventHandler(this.button_Clicked);
                    this.addToDay[i].Size = new System.Drawing.Size(80, 20);
                    this.addToDay[i].Text = "Add To " + lines[i];
                    this.addToDay[i].Click += new System.EventHandler(this.button_Clicked);
                    this.Controls.Add(this.addToDay[i]);
                }
            }
        }
    
       private void button_Clicked(object sender, EventArgs e)
        {
            Button triggeredButton = (Button) sender;
            
            var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
            var match = numAlpha.Match(triggeredButton.Name);
            var num = match.Groups["Numeric"].Value;
            this.exercises[num].Text = string.Empty;
            this.sets[num].Text = string.Empty;
            this.reps[num].Text = string.Empty;
        }
