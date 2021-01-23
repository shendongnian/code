    public class FormulariosENT {
        #region PROPERTIES
        public int IdFromulario { get; set; }
        public string DescripcionFormulario { get; set; }
        #endregion
        #region PUBLIC METHODS
        public override string ToString() {
            return DescripcionFormulario;
        }
