            /// <summary>
        /// Change the check state of the given object to be the given state.
        /// </summary>
        /// <remarks>
        /// If the given model object isn't in the list, we still try to remember
        /// its state, in case it is referenced in the future.</remarks>
        /// <param name="modelObject"></param>
        /// <param name="state"></param>
        /// <returns>True if the checkedness of the model changed</returns>
        protected override bool SetObjectCheckedness(object modelObject, CheckState state) {
            // If the checkedness of the given model changes AND this tree has 
            // hierarchical checkboxes, then we need to update the checkedness of 
            // its children, and recalculate the checkedness of the parent (recursively)
            bool result = SetObjectCheckednessHelper(modelObject, state, 0);
            if (this.AfterTreeCheckAndRecalculate != null)
                this.AfterTreeCheckAndRecalculate(this); //report that work is done
            return result;
        }
        protected bool SetObjectCheckednessHelper(object modelObject, CheckState state, int i) //recursive
        {
            if (!base.SetObjectCheckedness(modelObject, state))
                return false;
            if (!this.HierarchicalCheckboxes)
                return true;
            // Give each child the same checkedness as the model
            CheckState? checkedness = this.GetCheckState(modelObject);
            if (!checkedness.HasValue || checkedness.Value == CheckState.Indeterminate)
                return true;
            foreach (object child in this.GetChildrenWithoutExpanding(modelObject))
            {
                this.SetObjectCheckednessHelper(child, checkedness.Value, i+1);
            } //(un)check all children checkboxes
            if (i == 0) //recalculate upper levels only in the case of first call
            {
                ArrayList args = new ArrayList();
                args.Add(modelObject);
                this.RecalculateHierarchicalCheckBoxGraph(args); //all upper checkboxes in intermediate state or (un)check 
            }   
            return true;
        }
