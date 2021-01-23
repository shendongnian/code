    public class MyContext : DbContext
    {
        //...
        public Stage StageONE
        {
            get
            {
                var stage = this.Stages.Local.SingleOrDefault(s => s.StageId == 0);
                if (stage == null)
                {
                    stage = new Stage()
                    {
                        StageId = stageId,
                        Name = "ONE",
                        Span = new TimeSpan(0, 0, 0)
                    };
                    this.Stages.Attach(stage)
                }
                return stage;
            }
        }
    }
