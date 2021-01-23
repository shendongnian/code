    public static ArrayList RemoveTheSmallPipes(ArrayList lstPipeTypes)
    {
        
        for (int i = 0; i < lstPipeTypes.Count; i++)
        {
            ArrayList pipesToRemove = new ArrayList();
            int pipeCount = ((PipesList)lstPipeTypes[i]).Pipes.Count;
            for (int j = 0; j < pipeCount; j++)
            {
                if (((Pipe)((PipesList)lstPipeTypes[i]).Pipes[j]).length < 19)
                {
                    pipesToRemove.Add(j);
                }
            }
            for (int k = 0; k < pipesToRemove.Count; k++)
            {
                ((PipesList)lstPipeTypes[i]).Pipes.RemoveAt((int)pipesToRemove[k]);
            }
        }
        return lstPipeTypes;
    }
