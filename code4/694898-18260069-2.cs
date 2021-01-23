    public void UpdateCamera(float yaw, float pitch, Vector3 position)
    {
        Matrix cameraRotation = Matrix.CreateRotationX(pitch) * Matrix.CreateRotationY(yaw);
        Vector3 cameraOriginalTarget = new Vector3(0, 0, -1);
        Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
        Vector3 cameraFinalTarget = position + cameraRotatedTarget;
        Vector3 cameraOriginalUpVector = new Vector3(0, 1, 0);
        Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);
        view = Matrix.CreateLookAt(position, cameraFinalTarget, cameraRotatedUpVector);
    }
