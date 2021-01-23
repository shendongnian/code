        private bool NodeFiltering(TreeNode Nodo,string Texto)
        {
            bool resultado = false;
            if (Nodo.Nodes.Count == 0)
            {
                if (Nodo.Text.ToUpper().Contains(Texto.ToUpper()))
                {
                    resultado = true;
                }
                else
                {
                    Nodo.Remove();
                }
            }
            else
            {
                for (int i = Nodo.Nodes.Count; i > 0; i--)
                {
                    if (NodeFiltering(Nodo.Nodes[i - 1], Texto))
                        resultado = true;
                }
                if (!resultado)
                    Nodo.Remove();
            }
            return resultado;
        }
