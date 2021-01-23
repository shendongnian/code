    private void BtnGetFile_Click(object sender, EventArgs e)
        {
            string Line;
            int count = 0;
            try
            {
                StreamReader ReadFile;
                StringFileName = Interaction.InputBox(" Please Enter Your Desired File Name \n You do not need to place the '.txt' at the end of the file name.") + ".txt";
                ReadFile = File.OpenText(StringFileName);
                LbSongs.Items.Clear();
                while (!ReadFile.EndOfStream)
                {
                    Line = ReadFile.ReadLine();
                    string[] words = Line.Split(',');
                    ListSongs[count].NameOfSong = words[0];
                    ListSongs[count].NameOfArtist = words[1];
                    ListSongs[count].NameOfFile = words[2];
                    ListSongs[count].ThisWeekRank = words[3];
                    ListSongs[count].MostWeekRank = words[4];
                    ListSongs[count].LastWeekRank = words[5];
                    LbSongs.Items.Add(ListSongs[count].NameOfSong);
                    count++;
                }
                LbSongs.SelectedIndex = 0;
                Show();
                ReadFile.Close();
            }
            catch
            {
                MessageBox.Show("The file you are trying to access either, can not be found or opened");
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Program was created by Konrad Lazarek.\n\nOn April 16st, 2014.\n\nVersion: 00:03:48:59",
            "Info On This Program",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1);
        }
        private void BTF(int index)
        {
            switch (ListSongs[index].NameOfSong)
            {
                case "Happy":
                    HidePictures();
                    PicHappy.Visible = true;
                    break;
                case "All Of Me":
                    HidePictures();
                    PicAllOfMe.Visible = true;
                    break;
                case "Dark Horse":
                    HidePictures();
                    PicDarkHorse.Visible = true;
                    break;
                case "Talk Dirty":
                    HidePictures();
                    PicTalkDirty.Visible = true;
                    break;
                case "Let It Go":
                    HidePictures();
                    PicLetItGo.Visible = true;
                    break;
                case "Pompeii":
                    HidePictures();
                    PicPompeii.Visible = true;
                    break;
                case "Team":
                    HidePictures();
                    PicTeam.Visible = true;
                    break;
                case "Counting Stars":
                    HidePictures();
                    PicCountingStars.Visible = true;
                    break;
                case "The Man":
                    HidePictures();
                    PicTheMan.Visible = true;
                    break;
                case "Turn Down For What":
                    HidePictures();
                    PicTurnDownForWhat.Visible = true;
                    break;
            }
        }
