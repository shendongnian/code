    // info to send to all active missiles
    public class MissileInfoMessage { }
    // all missile classes should implement:
    public interface MissileInfoSubscriber {
    	void Notify (MissileInfoMessage msg);
    }
    public class MissileInfoBroker {
    	List<MissileInfoSubscriber> missileInfoSubscribers;
    	// targets, winds, airplanes calls this to get all missiles notified
    	public void NotifyMissiles (MissileInfoMessage msg) {
    		foreach (MissileInfoSubscriber missile in missileInfoSubscribers) {
    			missile.Notify (msg);
    		}
    	}
    	// missiles register when they got fired
    	public void Register (MissileInfoSubscriber s) {
    		missileInfoSubscribers.Add (s);
    	}
    	// and deregister if their job is done
    	public void Unregister (MissileInfoSubscriber s) {
    		missileInfoSubscribers.Remove (s);
    	}
    }
