        private void btnDelete_Click(object sender, EventArgs e)
        {
            int lstindex = lstStudents.SelectedIndex;
            if (lstindex != -1)
            {
                //Delete the data for a student in the array
                //and listbox, and keep the array and listbox synchronized.
                //names[lstindex] = null;
                lstStudents.Items.RemoveAt(lstindex);
                // starting at the index to remove, copy the value from the next index up, then iterate
                // this will shift everything down to replace the item being deleted
                for (int i = lstindex; i < names.GetUpperBound(0) - 1; i++)
                {
                    names[i, STUDENT_NAME] = names[i + 1, STUDENT_NAME];
                    names[i, STUDENT_ID] = names[i + 1, STUDENT_ID];
                    names[i, MAJOR] = names[i + 1, MAJOR];
                }
                //clear out the last entry:
                names[names.GetUpperBound(0), STUDENT_NAME] = "";
                names[names.GetUpperBound(0), STUDENT_ID] = "";
                names[names.GetUpperBound(0), MAJOR] = "";
            }
        }
