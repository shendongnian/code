    class InformationHolder {
        private static InformationHolder singleton = null;
        public List<float> graphData; //Can be any kind of variable (List<GraphInfo>, GraphInfo[]), whatever you like best.
        public static InformationHolder Instance() {
            if (singleton == null) {
                singleton = new InformationHolder();
            }
            return singleton;
        }
    }
