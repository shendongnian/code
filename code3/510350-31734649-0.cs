    class FadingOverlayForm : Form
        {
            readonly double fFinalOpacity;
         
            public FadingOverlayForm(Form owner, double finalOpacity)
            {
                StartPosition = FormStartPosition.Manual;
                FormBorderStyle = FormBorderStyle.None;
                ShowInTaskbar = false;
                Owner = owner;
                BackColor = Color.FromArgb(235, 245, 255); // or pick your own color
                fFinalOpacity = finalOpacity;
                if (fFinalOpacity < 0.01) fFinalOpacity = 0.01;
                else if (fFinalOpacity > 1.0) fFinalOpacity = 1.0;
            }
         
            public void FadeIn(TimeSpan duration)
            {
                Opacity = 0.01;
                Rectangle lWorkingArea = CalculateTotalScreenBounds();
                Bounds = new Rectangle(lWorkingArea.X - 150, lWorkingArea.Y - 150, 100, 100);
                Show();
                Bounds = new Rectangle(Owner.PointToScreen(Point.Empty), Owner.ClientSize);
                Animator.Animate(this, "Opacity", 0.01, fFinalOpacity, duration);
            }
         
            public void FadeOut(TimeSpan duration)
            {
                Animator.Animate(this, "Opacity", Opacity, 0, duration, EndFadeOut);
            }
         
            void EndFadeOut()
            {
                Form lOwner = Owner;
                Dispose();
                if (lOwner != null && !lOwner.IsDisposed)
                    ActivateFirstOwnedForm(lOwner);
            }
         
            static void ActivateFirstOwnedForm(Form form)
            {
                foreach(Form lOwnedForm in form.OwnedForms)
                    if (!lOwnedForm.IsDisposed)
                    {
                        ActivateFirstOwnedForm(lOwnedForm);
                        return;
                    }
                form.Activate();
            }
         
            static Rectangle CalculateTotalScreenBounds()
            {
                Rectangle lBounds = Rectangle.Empty;
                foreach(Screen lScreen in Screen.AllScreens)
                    lBounds = Rectangle.Union(lBounds, lScreen.Bounds);
                return lBounds;
            }
        }
