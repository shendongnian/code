    Drawable icon_error = Resources.GetDrawable(Resource.Drawable.icon_error);//this should be your error image.
    icon_error.SetBounds(0,0,icon_error.IntrinsicWidth,icon_error.IntrinsicHeight);
    
    if (txtsubiect.Text.Length <= 0)
                         	{
                                txtsubiect.RequestFocus();
                                txtsubiect.SetError("Eroare,camp gol!", icon_error );
                            }
