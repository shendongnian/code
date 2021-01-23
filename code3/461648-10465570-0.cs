                foreach (Form S in Application.OpenForms)
                {
                    var frm = S as Formes.CameraViewVS;
                    if (frm != null && frm.Addresse == cameraInstance[l].adresse) {
                        // Match, activate it
                        cameraInstance[l].MoveDetection = false;
                        frm.WindowState = FormWindowState.Normal;
                        frm.Activate();
                        return;
                    }
                }
                // No match found, create a new one
                var f1 = new Formes.CameraViewVS(cameraInstance[l], adresseIPArray[l]);
                f1.Show(this);
