    private void changePasswordbutton_Click_1(object sender, EventArgs e)
    {
        using (var waitForm = new waitForm()) {
            waitForm.Activated += (s,e) => {
                Thread thread = new Thread(state => {
                    try {
                        ProcessInkPresenter();
                        // If ProcessInkPresenter fails, this line will never execute
                        waitForm.Invoke(new Action(()=>waitForm.Hide()));
                    }
                    catch (Exception ex) {
                        // You probably want to do something with ex here,
                        // rather than just swallowing it.
                    }
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            waitForm.Show();
        }
    }
