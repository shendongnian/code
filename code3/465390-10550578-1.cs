    static void Main(string[] args)
    {
        var pipeTypes = new List<PipePile>();
        pipeTypes.Add(new PipePile("PVC Pipes", new List<Pipe>
            {
                new Pipe { Name = "The blue pipe", Length = 12 },
                new Pipe { Name = "The red pipe", Length = 15 },
                new Pipe { Name = "The silver pipe", Length = 6 },
                new Pipe { Name = "The green pipe", Length = 52 }
            }));
        pipeTypes.Add(new PipePile("Iron Pipes", new List<Pipe>
            {
                new Pipe { Name = "The gold pipe", Length = 9 },
                new Pipe { Name = "The orange pipe", Length = 115 },
                new Pipe { Name = "The pink pipe", Length = 1 }
            }));
        pipeTypes.Add(new PipePile("Chrome Pipes", new List<Pipe>
            {
                new Pipe { Name = "The grey pipe", Length = 12 },
                new Pipe { Name = "The black pipe", Length = 15 },
                new Pipe { Name = "The white pipe", Length = 19 },
                new Pipe { Name = "The brown pipe", Length = 60 },
                new Pipe { Name = "The peach pipe", Length = 16 }
            }));
        // Remove all pipes with length longer than 19
        pipeTypes.ForEach(pile => pile.Pipes.RemoveAll(pipe => pipe.Length > 19));
    }
