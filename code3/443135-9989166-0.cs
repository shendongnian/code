    foreach (L3Message message in por)
                {
                    treeViewMessages.Nodes.Add(message.Number + ": " + message.MessageName);
                    treeViewMessages.Nodes.Add("Time: " + message.Time);
                    treeViewMessages.Nodes.Add("MS: " + message.Device);
                    treeViewMessages.Nodes.Add("Scrambling Code: " + message.ScramblingCode);
                    foreach (Parameter param in message.Parameters)
                    {
                        TreeNode tnRootParam = new TreeNode();
                        //tnRootParam.Nodes.Add(param.ParameterName + ": " + param.ParameterValue);
                        if (param.SubParameters.Count != 0)
                        {
                            CreateTreeNodes(param, tnRootParam);
                            tnRootParam.Text = param.ParameterName;
                            treeViewMessages.Nodes.Add(tnRootParam);
                        }
                        else
                        {
                            tnRootParam.Text = param.ParameterName + ": " + param.ParameterValue;
                            treeViewMessages.Nodes.Add(tnRootParam);
                        }
                    }
                    treeViewMessages.Nodes.Add("---------------------------------------------------------------------");
                }
    private void CreateTreeNodes(Parameter parameter, TreeNode tnRootParam)
        {
            
            if (parameter.SubParameters.Count == 0)
            {
                tnRootParam.Nodes.Add(parameter.ParameterName + ": " + parameter.ParameterValue);
            }
            else
            {
                foreach (Parameter subparam in parameter.SubParameters)
                {
                    CreateTreeNodes(subparam, tnRootParam);
                }  
            }
        }
