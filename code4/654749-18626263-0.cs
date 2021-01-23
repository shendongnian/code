I think, since you're creating the button manually, you may need to use this code instead (I am assuming that you're using the Windows Forms Button control):
    switchScreen.Location = new System.Drawing.Point(xLocation, yLocation);
    switchScreen.Name = name;
    switchScreen.Size = new System.Drawing.Size(xSize, ySize);
    switchScreen.TabIndex = 0;
    switchScreen.Text = text;
    switchScreen.UseVisualStyleBackColor = true;
    
    Controls.Add(switchScreen);
