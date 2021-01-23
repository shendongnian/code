    public class VoiceSelector extends Activity {
    private TextToSpeech myTts;
    private int myEngineIndex; // loop counter when initializing TTS engines
    // Called from onCreate to colled all languages and voices from all TTS engines, initialize the spinners
    private void getEnginesAndLangs() {
        myTts = new TextToSpeech(AndyUtil.getAppContext(), null);
        List<EngineInfo> engines;
        engines = myTts.getEngines(); // at least we can get the list of engines without initializing myTts object…
        try { myTts.shutdown(); } catch (Exception e) {};
        myTts = null;
        myEngineIndex = 0; // Initialize the loop iterating through all TTS engines
        if (engines.size() > 0) {
            for (EngineInfo ei : engines)
                allEngines.add(new EngLang(ei));
            myTts = new TextToSpeech(AndyUtil.getAppContext(), ttsInit, allEngines.get(myEngineIndex).name());
            // DISRUPTION 1: we can’t continue here, must wait until  ttsInit callback returns, see below
        }
    }
    private TextToSpeech.OnInitListener ttsInit = new TextToSpeech.OnInitListener() {
    @Override
    public void onInit(int status) {
        if (myEngineIndex < allEngines.size()) {
            if (status == TextToSpeech.SUCCESS) {
                // Ask a TTS engine which voices it currently has installed
                EngLang el = allEngines.get(myEngineIndex);
                Intent in = new Intent(TextToSpeech.Engine.ACTION_CHECK_TTS_DATA);
                in = in.setPackage(el.ei.name); // set engine package name
                try {
                    startActivityForResult(in, LANG_REQUEST); // goes to onActivityResult()
                    // DISRUPTION 2: we can’t continue here, must wait for onActivityResult()…
                } catch (Exception e) {   // ActivityNotFoundException, also got SecurityException from com.turboled
                    if (myTts != null) try {
                        myTts.shutdown();
                    } catch (Exception ee) {}
                    if (++myEngineIndex < allEngines.size()) {
                        // If our loop was not finished and exception happened with one engine,
                        // we need this call here to continue looping…
                        myTts = new TextToSpeech(AndyUtil.getAppContext(), ttsInit, allEngines.get(myEngineIndex).name());
                    } else {
                        completeSetup();
                    }
                }
            }
        } else
            completeSetup();
    }
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (requestCode == LANG_REQUEST) {
            // We return here after sending ACTION_CHECK_TTS_DATA intent to a TTS engine
            // Get a list of voices supported by the given TTS engine
            if (data != null) {
                ArrayList<String> voices = data.getStringArrayListExtra(TextToSpeech.Engine.EXTRA_AVAILABLE_VOICES);
                // … do something with this list to save it for later use
            }
            if (myTts != null) try {
                myTts.shutdown();
            } catch (Exception e) {}
            if (++myEngineIndex < allEngines.size()) {
                // and now, continue looping through engines list…
                myTts = new TextToSpeech(AndyUtil.getAppContext(), ttsInit, allEngines.get(myEngineIndex).name());
            } else {
                completeSetup();
            }
        }
    }
