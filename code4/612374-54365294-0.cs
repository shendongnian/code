         //ASYNCHRONOUS
        //this is called every 5 seconds
        async void CheckWeather()
        {
            var weather = await GetWeather();
            //do something with the weather now you have it
        }
        async Task<WeatherResult> GetWeather()
        {
            var weatherJson = await CallToNetworkAddressToGetWeather();
            return deserializeJson<weatherJson>(weatherJson);
        }
        //SYNCHRONOUS
        //This method is called whenever the screen is pressed
        void ScreenPressed()
        {
            DrawSketchOnScreen();
        }
