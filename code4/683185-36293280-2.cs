            private void buttonX1_Click(object sender, EventArgs e)
            {
                for (int i = 0; i <3; i++)
                {
                    pictureBoxs[i].Image =your_name_project.Properties.Resources.image_1;// load image1 and Image_2from resource in property of picturebox  
                }
                for (int i = 3; i < 6; i++)
                {
                    pictureBoxs[i].Image = your_name_project.Properties.Resources.Image_2;
                }
            } 
        }
}
