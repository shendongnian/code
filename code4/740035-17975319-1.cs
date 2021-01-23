        public static void DisableDecompression(this HttpTransportBindingElement bindingElement)
        {
    #if RUNNING_ON_4
            bindingElement.DecompressionEnabled = false;
    #endif
        }
