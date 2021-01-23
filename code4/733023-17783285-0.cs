    public class Towers: MonoBehaviour
    {
        public static float[] d = initD();
        public static float[] r = initR();
        public static float[] s = initS();
        public static float[] u = initU();
        private static float[] initD()
        {
            return new []
            {
                 1f,
                 3f,
                 5f,
                 7f,
                 9f,
                11f,
                13f,
                15f,
                18f,
                21f,
                23f
            };
        }
        private static float[] initR()
        {
            return new []
            {
                 5f,
                 9f,
                13f,
                17f,
                21f,
                25f,
                29f,
                33f,
                37f,
                41f,
                45f
            };
        }
        private static float[] initS()
        {
            return new []
            {
                3.0f,
                2.8f,
                2.6f,
                2.4f,
                2.2f,
                2.0f,
                1.8f,
                1.6f,
                1.4f,
                1.2f,
                1.0f
            };
        }
        private static float[] initU()
        {
            return new[]
            {
                 50f,
                100f,
                150f,
                200f,
                250f,
                300f,
                350f,
                400f,
                450f,
                500f,
                  0f
            };
        }
    }
