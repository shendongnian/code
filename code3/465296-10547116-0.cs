    public class PyramidenMain extends ProbabilityGame implements IProbabilityGame{
        public function PyramidenMain(){
    		super(this);
    		super.initialize();
    	}	
    	
    	//implement interface
    }
    
    public interface IProbabilityGame{
    		function getGame():MovieClip;
    		function customInit():void;
    		function customLoginSuccessful():void;
    		function customLoginError(xml:XML):void;
    		function customShowError(msg:String):void;
    		function createDemoProtocol():IProtocol;
    	}
    	
    public class ProbabilityGame {
    	public function ProbabilityGame(game:IProbabilityGame) {
    		if(game == null) {
    			throw new Exception("unmet requirement, parameter containing an instance of IProbabilityGame");
    		}
    		_game = game;
    	}
    	
    	public function initialize() {
    		//do some logic
    		_game.customInit();
    	}
    }
