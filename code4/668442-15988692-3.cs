    public class FiltreTbx
    {
        public static void AddTextBoxFilter(TextBox textbox,
                                            double tailleMini, double tailleMaxi,
                                            string carNonAutorisé)
        {
            string previousText = textbox.Text;
            textbox.TextChanged +=
                delegate(object sender, EventArgs e)
                {
                     textChanged(e, textbox, tailleMini, tailleMaxi,
                                 carNonAutorisé, previousText);
                     previousText = textbox.Text;
                };
        }
        static public void textChanged(EventArgs e, TextBox textbox,
                                       double tailleMini, double tailleMaxi,
                                       string carNonAutorisé, string previousText)
        {
            //Recherche dans la TextBox, la première occurrence de l'expression régulière.
            Match match = Regex.Match(textbox.Text, carNonAutorisé);
            /*Si il y a une Mauvaise occurence:
             *   - On efface le contenu collé
             *   - On prévient l'utilisateur 
             */
            if (match.Success)
            {
                // Set the Text back to the value it had after the previous
                // TextChanged event.
                textbox.Text = previousText;
                MessageBox.Show("Votre copie un ou des caractère(s) non autorisé",
                                "Attention", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            tailleTextBox(textbox, tailleMini, tailleMaxi);
        }
    }
