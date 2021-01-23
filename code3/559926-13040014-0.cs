    public class Form1 {
        public Form1() {
            ToolStripDropDown customToolTip = new ToolStripDropDown();
            customToolTip.Items.Add(new CustomPopupControl("Hello", "world"));
            MouseMove += (o, e) => {
                Point location = e.Location;
                location.Offset(0, 16);
                customToolTip.Show(this, location);
            };
        }
        class CustomPopupControl : ToolStripControlHost {
            public CustomPopupControl(string title, string message)
                : base(new Panel()) {
                Label titleLabel = new Label();
                titleLabel.BackColor = SystemColors.Control;
                titleLabel.Text = title;
                titleLabel.Dock = DockStyle.Top;
                Label messageLabel = new Label();
                messageLabel.BackColor = SystemColors.ControlLightLight;
                messageLabel.Text = message;
                messageLabel.Dock = DockStyle.Fill;
                Control.MinimumSize = new Size(90, 64);
                Control.Controls.Add(messageLabel);
                Control.Controls.Add(titleLabel);
            }
        }
    }
