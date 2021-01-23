    public GraphHandler(SubGraphController portionOfGraph) {
         this.portionOfGraph = portionOfGraph;
    }
    public SubGraphController(DeeperSubGraphController portionOfGraph) {
         this.portionOfGraph = portionOfGraph;
    }
    ...
    var zedGraphControl = new ZedGraphControl();
    var deeperSubGraphController = new DeeperSubGraphController(zedGraphControl);
    var subGraphController = new SubGraphController(deeperSubGraphController);
    var graphHandler = new GraphHandler(subGraphController);
