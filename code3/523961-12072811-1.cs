    public class FormUsersUpdate(User user, Action<User> callback)
    {
        // Update user, then invoke the callback using the updated user instance,
        // which will call the OnUserUpdated method of the FormMain:
        callback.Invoke(user);
    }
